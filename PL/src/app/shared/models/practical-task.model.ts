import { Answer } from "./answer.model";

export class PracticalTask {
    id : number;
    question : string;
    type : number;
    answers : Answer[];
}
