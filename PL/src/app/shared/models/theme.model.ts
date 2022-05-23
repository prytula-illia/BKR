import { PracticalTask } from "./practical-task.model";
import { StudyingMaterial } from "./studying-material.model";

export class Theme {
    id : number;
    title : string;
    description : string;
    tasks : PracticalTask[];
    studyingMaterials : StudyingMaterial[];
}
