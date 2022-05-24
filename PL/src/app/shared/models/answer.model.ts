export class Answer {
    id : number;
    content : string;
    isCorrect : boolean;

    constructor() {
        this.id = 0;
        this.content = '';
        this.isCorrect = false;
    }
}
