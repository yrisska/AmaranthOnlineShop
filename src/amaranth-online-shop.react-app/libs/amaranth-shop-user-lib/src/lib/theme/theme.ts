import { createTheme } from "@mui/material";

export const theme = createTheme({
  typography: {
    fontFamily: "Monsterrat Regular"
  }
});

theme.components = {
  MuiCssBaseline: {
    styleOverrides: {
      body: {
        "#root": {
          minHeight: "100vh",
          minWidth: "100vw",
          maxWidth: "100vw",
          overflowX: "hidden",
          overflowY: "auto",
          [theme.breakpoints.down("md")]: {
						flexDirection: "column",
					}
        }
      }
    }
  }
}