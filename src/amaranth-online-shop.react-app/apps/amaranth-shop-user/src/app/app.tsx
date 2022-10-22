// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { theme } from "@amaranth-online-shop.react-app/amaranth-shop-user-lib";
import { CssBaseline, ThemeProvider } from "@mui/material";
import { BrowserRouter } from "react-router-dom";
import AppRoutes from "../routes";

export function App() {
  return (
    <ThemeProvider theme={theme}>
      <BrowserRouter>
        <CssBaseline />
        <AppRoutes />
      </BrowserRouter>
    </ThemeProvider>
  );
}

export default App;
