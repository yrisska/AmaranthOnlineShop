// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { theme } from "@amaranth-online-shop.react-app/amaranth-shop-user-lib";
import { store } from "@amaranth-online-shop.react-app/redux";
import { Auth0Provider } from "@auth0/auth0-react";
import { CssBaseline, ThemeProvider } from "@mui/material";
import { Provider } from "react-redux";
import { BrowserRouter } from "react-router-dom";
import persistStore from "redux-persist/es/persistStore";
import { PersistGate } from "redux-persist/integration/react";
import { environment } from "../environments/environment";
import AppRoutes from "../routes";

const persistor = persistStore(store);

export function App() {
  return (
    <ThemeProvider theme={theme}>
      <BrowserRouter>
        <Provider store={store}>
          <PersistGate persistor={persistor}>
            <Auth0Provider
              domain={environment.auth0Domain}
              clientId={environment.auth0ClientId}
              audience={environment.auth0Audience}
              redirectUri={window.location.origin}
              useRefreshTokens={true}
              cacheLocation="localstorage"
            >
              <CssBaseline />
              <AppRoutes />
            </Auth0Provider>
          </PersistGate>
        </Provider>
      </BrowserRouter>
    </ThemeProvider>
  );
}

export default App;
