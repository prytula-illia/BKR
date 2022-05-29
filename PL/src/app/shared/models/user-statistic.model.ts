import { Course } from "./course.model";
import { Theme } from "./theme.model";

export class UserStatistic {
    id : number;
    userLogin : string;
    rating : number;
    finishedCourses : Course[];
    finishedThemes : Theme[];

    constructor() {
        this.id = 0;
        this.userLogin = '';
        this.rating = 0;
        this.finishedCourses = [];
        this.finishedThemes = [];
    }
}
