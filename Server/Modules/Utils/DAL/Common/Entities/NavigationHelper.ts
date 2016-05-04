
class NavigationHelper<T> {
    constructor() { }

    private paths: string[] = [];

    include(path: (arg: T) => any): NavigationHelper<T> {
        var result = this.getPath(path)
        this.paths.push(result);
        return this;
    }

    private getPath(path: Function): string {
        var mode = "ES5"; // ES5 - function or ES6 - lambda
        var result = "";
        switch (mode) {
            case "ES5":
                result = this.trimBody(this.getFnBodyFromFunction(path));
                break;
            case "ES6":
                result = this.trimBody(this.getFnBodyFromLambda(path));
                break;
        }
        return result;
    }

    // Info credit: http://stackoverflow.com/questions/10805125/how-to-remove-all-line-breaks-from-a-string#answer-10805198
    private trimBody(body: string): string {
        var result = body.replace(/(\r\n|\n|\r)/g, "").replace(/;/, "").replace(/.select\(\)/g, "").trim();
        var headIndex = result.indexOf(".");
        result = result.substring(headIndex + 1);
        return result;
    }

    // Info credit: http://www.paulfree.com/11/javascript-lambda-expressions/
    //(it) => it.OrgTblDepartamente.MatTblDepartFunctAsocs.select().OrgTblDepartamente.OrgTblDepartFunctPersonals.select().OrgTblPersonalRolesAsociations
    private getFnBodyFromLambda(fn: Function): string {
        var fnString = fn.toString();
        var match = fnString.match(/\((.*)\)\s*=>\s*(.*)/);
        return match[1];
    }

    // Info credit: http://stackoverflow.com/questions/8187857/regular-expression-to-extract-function-body#answer-22204117
    //function (it) {
    //    return it.OrgTblDepartamente.MatTblDepartFunctAsocs.select().OrgTblDepartamente.OrgTblDepartFunctPersonals.select().OrgTblPersonalRolesAsociations;
    //}
    private getFnBodyFromFunction(fn: Function): string {
        var fnString = fn.toString();
        var match = fnString.match(/(function\s?)([^\.])([\w|,|\s|-|_|\$]*)(.+?\{)([^\.][\s|\S]*(?=\}))/); // fnString.match(/{(?s:.*)\}/);
        return match[5];
    }

    all(): string[] {
        var result = this.paths;
        this.paths = [];
        return result;
    }

    single(): string {
        var result = "";
        if (this.paths.length) {
            result = this.paths[0];
            this.paths = [];
        }
        return result;
    }

    static for<T>() {
        return new NavigationHelper<T>();
    }

}

export = NavigationHelper;