import { productsPagedUri } from "../constants";
import { ProductPagedQuery, ProductPagedResult } from "../types";



export const getPagedProducts = async (pagedRequest: ProductPagedQuery) : Promise<ProductPagedResult | null> => {
  const response = await fetch(productsPagedUri + new URLSearchParams(pagedRequest), {
    method: "GET"
  });

  return response.ok ? response.json() as Promise<ProductPagedResult> : null;
}