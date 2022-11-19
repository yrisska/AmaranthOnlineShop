import {
  GetIdTokenClaimsOptions,
  GetTokenSilentlyOptions,
  IdToken,
  LogoutOptions, User
} from "@auth0/auth0-react";
import { AuthProvider } from "react-admin";
import { environment } from "../environments/environment";

const authProvider = (options: {
  isAuthenticated: boolean,
  isLoading: boolean,
  getIdTokenClaims: (options?: GetIdTokenClaimsOptions | undefined) => Promise<IdToken | undefined>,
  logout: (options?: LogoutOptions | undefined) => void,
  user: User,
  getAccessTokenSilently: (options?: GetTokenSilentlyOptions | undefined) => Promise<string>
}): AuthProvider => ({

  login: async () => {
    if (!options.isLoading && !options.isAuthenticated) {
      return Promise.reject();
    }
    const token = await options.getIdTokenClaims();
    if (!token) {
      return Promise.reject();
    }
    const roles = token[environment.auth0RolesPath] as string[] | undefined;
    if (!roles || !roles.includes("Admin")) {
      return Promise.reject();
    }
    return Promise.resolve();
  },

  logout: () => {
    options.logout({ returnTo: window.location.origin });
    return Promise.resolve();
  },

  checkError: () => Promise.resolve(),

  checkAuth: async () => {
    if (!options.isLoading && !options.isAuthenticated) {
      return Promise.reject();
    }
    return Promise.resolve();
  },

  getPermissions: () => options.getAccessTokenSilently(),

  getIdentity: () =>
    Promise.resolve({
      id: options.user["id"],
      fullName: options.user.name,
      avatar: options.user.picture,
    }),

});

export default authProvider;