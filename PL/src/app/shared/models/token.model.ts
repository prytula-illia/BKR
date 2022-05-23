export class Token {
    token : string;
    expiration : Date;

    constructor(){
        this.token = "";
        this.expiration = new Date();
    }
}
