import { PracticalTask } from "./practical-task.model";
import { StudyingMaterial } from "./studying-material.model";
import { ThemeRating } from "./theme-rating.model";

export class Theme {
    id : number;
    title : string;
    description : string;
    createdByUser : string;
    tasks : PracticalTask[];
    studyingMaterials : StudyingMaterial[];
    courseId : number;
    themeRatings : ThemeRating[];

    constructor() {
        this.id = 0;
        this.title = "";
        this.description = "";
        this.createdByUser = "";
        this.tasks = [];
        this.studyingMaterials = [];
        this.courseId = 0;
        this.themeRatings = [];
    }
}
