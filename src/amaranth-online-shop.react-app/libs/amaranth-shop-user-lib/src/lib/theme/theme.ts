import { createTheme } from "@mui/material";

export const theme = createTheme({
  typography: {
    fontFamily: "Monsterrat Regular"
  },
  palette: {
    primary: {
      main: "#9CCEA7",
      dark: "#76BB87",
      light: "#EAF6E8",
      contrastText: "black"
    },
    secondary: {
      main: "#FAF3D7",
      dark: "#D5C9BD",
      contrastText: "black",
    }
  }
});

theme.components = {
  MuiCssBaseline: {
    styleOverrides: {
      body: {
        "#root": {
          minHeight: "100vh",
          minWidth: "100%",
          maxWidth: "100%",
          maxHeight: "100vh",
          [theme.breakpoints.down("md")]: {
						flexDirection: "column",
					}
        },
      }
    }
  },
  
}