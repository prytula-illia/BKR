export class CommentRating {
    username : string;
    like : boolean;
    dislike : boolean;
    commentId : number;

    constructor() {
        this.username = "";
        this.like = false;
        this.dislike = false;
        this.commentId = 0;
    }
}
