export class UserComment {
    id : number;
    userName : string;
    content : string;
    dateTime : Date;

    constructor() {
        this.id = 0;
        this.userName = '';
        this.content = '';
        this.dateTime = new Date();
    }
}
