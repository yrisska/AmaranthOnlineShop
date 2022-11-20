import { DataProvider } from "react-admin";
import { store, productsApiSlice } from "@amaranth-online-shop.react-app/redux";
import { GetTokenSilentlyOptions } from "@auth0/auth0-react";

export const productProvider = (getAccessTokenSilently: (options?: GetTokenSilentlyOptions | undefined) => Promise<string>) => {

  return ({
    getList: (
      resource, params
    ) => {
      const result = store.dispatch(productsApiSlice.endpoints.getPagedProducts.initiate({
        pageIndex: params.pagination.page + "",
        pageSize: params.pagination.perPage + "",
        sortingColumnName: params.sort.field,
        sortDirection: params.sort.order,
        productCategoryId: params.filter["productCategoryId"] || "",
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
      const result = store.dispatch(productsApiSlice.endpoints.getProductById.initiate(params.id)).unwrap();

      return result.then(product => ({
        data: product
      })).catch(x => Promise.reject("Something went wrong"));
    },

    update: async (
      resource, params
    ) => {
      const token = await getAccessTokenSilently();
      const result = store.dispatch(productsApiSlice.endpoints.updateProduct.initiate({
        data: {
          id: params.data["id"],
          name: params.data["name"],
          description: params.data["description"],
          price: params.data["price"],
          productCategoryId: params.data["productCategoryId"],
        },
        file: params.data["imageFile"] ? params.data["imageFile"]["rawFile"] : null,
        token: token
      })).unwrap();

      return result.then(data => ({
        data: data
      })).catch(x => Promise.reject("Something went wrong"));
    },

    create: async (
      resource, params
    ) => {
      const token = await getAccessTokenSilently();

      const result = store.dispatch(productsApiSlice.endpoints.createProduct.initiate({
        data: {
          name: params.data["name"],
          description: params.data["description"],
          price: params.data["price"],
          productCategoryId: params.data["productCategoryId"],
        },
        file: params.data["imageFile"] ? params.data["imageFile"]["rawFile"] : null,
        token: token
      })).unwrap();

      return result.then(data => ({
        data: data
      })).catch(x => Promise.reject("Something went wrong"));
    },

    delete: async (
      resource, params
    ) => {
      console.log(params);
      const token = await getAccessTokenSilently();
      const result = store.dispatch(productsApiSlice.endpoints.deleteProduct.initiate({ id: params.id.toString(), token: token })).unwrap();

      console.log(token);
      return result.then(data => ({
        data: data
      })).catch(x => Promise.reject("Something went wrong"));
    },
  } as DataProvider);
};