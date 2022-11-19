import { DataProvider } from "react-admin";
import { productCategoriesApiSlice, store } from "@amaranth-online-shop.react-app/redux";
import { GetTokenSilentlyOptions } from "@auth0/auth0-react";

export const productCategoryProvider = (getAccessTokenSilently: (options?: GetTokenSilentlyOptions | undefined) => Promise<string>) => ({
  getList: (
    resource, params
  ) => {
    const result = store.dispatch(productCategoriesApiSlice.endpoints.getPagedProductCategories.initiate({
      pageIndex: params.pagination.page + "",
      pageSize: params.pagination.perPage + "",
      sortingColumnName: params.sort.field,
      sortDirection: params.sort.order,
      name: params.filter["name"] || "",
    })).unwrap();

    return result.then(data => ({
      data: data.items,
      total: data.total,
      pageInfo: {
        hasNextPage: data.hasNextPage,
        hasPreviousPage: data.hasPreviousPage
      }
    })).catch(x => Promise.reject("Something went wrong"));
  },

  getOne: (
    resource, params
  ) => {
    const result = store.dispatch(productCategoriesApiSlice.endpoints.getProductCategoryById.initiate(params.id)).unwrap();

    return result.then(productCategory => ({
      data: productCategory
    })).catch(x => Promise.reject("Something went wrong"));
  },
  getMany(
    resource, params
  ) {
    const result = store.dispatch(productCategoriesApiSlice.endpoints.getManyProductCategories.initiate(params.ids)).unwrap();

    return result.then(data => ({
      data: data
    })).catch(x => Promise.reject("Something went wrong"));
  },
} as DataProvider);