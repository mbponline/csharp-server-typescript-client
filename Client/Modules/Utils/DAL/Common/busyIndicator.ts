
class BusyIndicator {
    constructor() {
        this.isBusy = false;
        this.busyCount = 0;
    }

    private isBusy: boolean;
    private busyCount: number;

    start(): void {
        setTimeout(() => {
            if (this.busyCount > 0 && !this.isBusy) {
                // TODO: add start logic
                this.isBusy = true;
            }
        }, 500);
        this.busyCount++;
    }

    stop(): void {
        this.busyCount--;
        if (this.busyCount === 0 && this.isBusy) {
            // TODO: add stop logic
            this.isBusy = false;
        }
    }

    static instance = new BusyIndicator();

}

export = BusyIndicator;

