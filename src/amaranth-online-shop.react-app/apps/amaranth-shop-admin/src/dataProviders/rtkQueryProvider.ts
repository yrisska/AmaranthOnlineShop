import { GetTokenSilentlyOptions } from "@auth0/auth0-react";
import { combineDataProviders } from "react-admin";
import { productCategoryProvider } from "./productCategoryProvider";
import { productProvider } from "./productProvider";

export const rtkQueryProvider = (getAccessTokenSilently: (options?: GetTokenSilentlyOptions | undefined) => Promise<string>) => combineDataProviders((resource) => {
  switch (resource) {
    case "products":
      return productProvider(getAccessTokenSilently);
    case "product-categories":
      return productCategoryProvider(getAccessTokenSilently);
    default:
      throw new Error(`Unknown resource: ${resource}`);
  }
});