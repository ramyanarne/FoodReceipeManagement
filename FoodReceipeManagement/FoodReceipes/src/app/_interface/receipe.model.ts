import { ReceipeIngredient } from "./receipeIngredient.model";
import { ReceipeInstruction } from "./receipeInstruction.model";

export interface Receipe {
    receipeId : number
    name : string;
    cookingTime : number;
    description : string,
    receipeIngredients : Array<ReceipeIngredient>
    receipeInstructions : Array<ReceipeInstruction>
}