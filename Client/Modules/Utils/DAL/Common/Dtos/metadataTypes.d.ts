// http://json2ts.com/

declare module metadataTypes {

    export interface Parameter {
        name: string;
        type: string;
        nullable: boolean;
    }

    export interface ReturnType {
        type: string;
        isEntity: boolean;
        isCollection: boolean;
        nullable: boolean;
    }

    //export interface Function {
    //    name: string;
    //    parameters: Parameter[];
    //    returnType: ReturnType;
    //}

    //export interface Action {
    //    name: string;
    //    parameters: Parameter[];
    //    returnType?: ReturnType;
    //}

    export interface Operation {
        name: string;
        parameters: Parameter[];
        returnType: ReturnType;
    }

    export interface Property {
        fieldName: string;
        type: string;
        nullable: boolean;
        default: number;
        maxLength?: any;
    }

    export interface NavigationProperty {
        entityTypeName: string;
        multiplicity: string;
        keyLocal: string[];
        keyRemote: string[];
    }

    export interface EntityType {
        tableName: string;
        entitySetName: string;
        key: string[];
        properties: IDictionary<Property>;
        calculatedProperties: string[];
        navigationProperties: IDictionary<NavigationProperty>;
    }

    export interface Multiplicity {
        multi: string;
        single: string;
    }

    export interface Metadata {
        dialect: string;
        version: string;
        description: string;
        namespace: string;
        max: number;
        multiplicity: Multiplicity;
        entityTypes: IDictionary<EntityType>;
        functions: Operation[];
        actions: Operation[];
    }

}

