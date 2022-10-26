// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { theme } from "@amaranth-online-shop.react-app/amaranth-shop-user-lib";
import { store } from "@amaranth-online-shop.react-app/redux";
import { CssBaseline, ThemeProvider } from "@mui/material";
import { Provider } from "react-redux";
import { BrowserRouter } from "react-router-dom";
import persistStore from "redux-persist/es/persistStore";
import { PersistGate } from "redux-persist/integration/react";
import AppRoutes from "../routes";
const persistor = persistStore(store);

export function App() {
  return (
    <ThemeProvider theme={theme}>
      <BrowserRouter>
        <Provider store={store}>
          <PersistGate persistor={persistor}>
            <CssBaseline />
            <AppRoutes />
          </PersistGate>
        </Provider>
      </BrowserRouter>
    </ThemeProvider>
  );
}

export default App;
