import { productCategoriesUri } from "../constants";
import { ProductCategoryDto } from "../types";

export const getProductCategories = async () : Promise<Array<ProductCategoryDto> | null> => {
  const response = await fetch(productCategoriesUri, {
    method: "GET"
  });

  return response.ok ? response.json() as Promise<Array<ProductCategoryDto>> : null;
}