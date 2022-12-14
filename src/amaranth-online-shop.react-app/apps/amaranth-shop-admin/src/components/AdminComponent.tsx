import { useAuth0, User } from "@auth0/auth0-react";
import { Admin, Resource } from "react-admin";
import authProvider from "../auth/authProvider";
import LoginPage from "../auth/LoginPage";
import { rtkQueryProvider } from "../dataProviders/rtkQueryProvider";
import ProductCategoryList from "../resources/productCategories/ProductCategoryList";
import ProductCreate from "../resources/products/ProductCreate";
import ProductEdit from "../resources/products/ProductEdit";
import ProductList from "../resources/products/ProductList";

export const AdminComponent = () => {

  const {
    isAuthenticated,
    logout,
    isLoading,
    user,
    getIdTokenClaims,
    getAccessTokenSilently,
  } = useAuth0();
  const customAuthProvider = authProvider({
    isAuthenticated,
    isLoading,
    getIdTokenClaims,
    logout,
    user: user ?? new User(),
    getAccessTokenSilently
  });

  return (
    <Admin
      loginPage={LoginPage}
      authProvider={customAuthProvider}
      dataProvider={rtkQueryProvider(getAccessTokenSilently)}
    >
      <Resource
        name="products"
        list={ProductList}
        create={ProductCreate}
        edit={ProductEdit}
      />
      <Resource
        name="product-categories"
        list={ProductCategoryList}
        recordRepresentation="name"
      />
    </Admin>
  );
};