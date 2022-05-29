import { UserComment } from "./user-comment.model";

export class StudyingMaterial {
    id : number;
    title : string;
    content : string;
    comments : UserComment[];

    constructor() {
        this.id = 0;
        this.title = "";
        this.content = "";
        this.comments = [];
    }
}
