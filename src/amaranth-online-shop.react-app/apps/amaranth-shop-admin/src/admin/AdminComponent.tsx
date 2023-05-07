import { useAuth0, User } from "@auth0/auth0-react";
import { Admin, Resource } from "react-admin";
import authProvider from "../auth/authProvider";
import LoginPage from "../auth/LoginPage";
import { rtkQueryProvider } from "../dataProviders/rtkQueryProvider";
import ProductCategoryCreate from "../resources/productCategories/ProductCategoryCreate";
import ProductCategoryEdit from "../resources/productCategories/ProductCategoryEdit";
import ProductCategoryList from "../resources/productCategories/ProductCategoryList";
import ProductCreate from "../resources/products/ProductCreate";
import ProductEdit from "../resources/products/ProductEdit";
import ProductList from "../resources/products/ProductList";
import InventoryIcon from "@mui/icons-material/Inventory";
import CategoryIcon from "@mui/icons-material/Category";

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
      requireAuth
    >
      <Resource
        name="products"
        list={ProductList}
        create={ProductCreate}
        edit={ProductEdit}
        icon={InventoryIcon}
      />
      <Resource
        name="product-categories"
        list={ProductCategoryList}
        create={ProductCategoryCreate}
        edit={ProductCategoryEdit}
        recordRepresentation="name"
        icon={CategoryIcon}
      />
    </Admin>
  );
};