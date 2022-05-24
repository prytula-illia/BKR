import { Theme } from "./theme.model";

export class Course {
    id : number;
    name : string;
    description : string;
    themes : Theme[];
    
    constructor(){
        this.id = 0;
        this.name = "";
        this.description = "";
        this.themes = [];
    }
}
