import { ProductPagedQuery, ProductPagedResult } from "@amaranth-online-shop.react-app/redux";
import { productsPagedUri } from "../constants";



export const getPagedProducts = async (pagedRequest: ProductPagedQuery) : Promise<ProductPagedResult | null> => {
  const response = await fetch(productsPagedUri + new URLSearchParams(pagedRequest), {
    method: "GET"
  });

  return response.ok ? response.json() as Promise<ProductPagedResult> : null;
}