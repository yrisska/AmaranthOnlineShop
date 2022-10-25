import { ProductCategoryDto } from "@amaranth-online-shop.react-app/redux";
import { productCategoriesUri } from "../constants";

export const getProductCategories = async () : Promise<Array<ProductCategoryDto> | null> => {
  const response = await fetch(productCategoriesUri, {
    method: "GET"
  });

  return response.ok ? response.json() as Promise<Array<ProductCategoryDto>> : null;
}