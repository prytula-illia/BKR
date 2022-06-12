import { CommentRating } from "./commentrating.model";

export class UserComment {
    id : number;
    userName : string;
    content : string;
    dateTime : Date;
    commentRatings : CommentRating[];

    constructor() {
        this.id = 0;
        this.userName = '';
        this.content = '';
        this.dateTime = new Date();
        this.commentRatings = [];
    }
}
