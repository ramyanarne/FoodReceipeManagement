import { Ingredient } from "./ingredient.model";
import { MeasurementUnit } from "./measurementUnit.model";

export interface ReceipeIngredient {
    receipeIngredientId: number;
    ingredient: Ingredient;
    measurementUnitId : number,
    quantity : number,
    measurementUnit : MeasurementUnit

}
