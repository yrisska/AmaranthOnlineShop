import { GridSize } from "@mui/material";
import { GridDirection, ResponsiveStyleValue } from "@mui/system";
import { theme } from "../../../theme/theme";

export const cartStyles = {
  root: {

  },
  titleContainer: {
    container: true,
    justifyContent: "space-between",
    alignItems: "center",
    paddingX: "1vw",
  },
  closeIcon: {
    scale: "1.3",
  },
  emptyCartContainer: {
    container: true,
    justifyContent: "center",
    alignItems: "center",
    height: "40vh",
  },
  cartContainer: {
    container: true,
    direction: "column" as ResponsiveStyleValue<GridDirection>,
    width: "100%",
    paddingRight: "2vh",
  },
  flexEndItemContainer: {
    item: true,
    container: true,
    xs: 12 as GridSize,
    justifyContent: "flex-end",
    marginY: "1vh"
  },
  cartItemContainer: {
    height: "19vh",
    item: true,
    container: true,
    alignItems: "center",
    justifyContent: "space-between",
  },
  productImg: {
    aspectRatio: "1",
    width: "100%",
    height: "auto"
  },
  nameQuantityContainer: {
    height: "100%",
    item: true,
    container: true,
    alignItems: "center",
    justifyContent: "space-evenly",
    direction: "column" as ResponsiveStyleValue<GridDirection>,
    xs: 4 as GridSize,
  },
  quantityContainer: {
    item: true,
    container: true,
    alignItems: "center",
    justifyContent: "space-around",
    xs: 4 as GridSize,
  },
  removePriceContainer: {
    height: "100%",
    item: true,
    container: true,
    alignItems: "flex-end",
    justifyContent: "space-evenly",
    direction: "column" as ResponsiveStyleValue<GridDirection>,
    xs: 4 as GridSize,
  },
  form: {
    paddingTop: "4vh",
    container: true,
    width: "100%",
    rowGap: "3vh",
    alignItems: "center",
    justifyContent: "space-evenly",
  },
  input: {
    width: "40%",
    height: "4vh",
    marginBottom: "3vh",
    [theme.breakpoints.down("md")]: {
      height: "12vh",
      width: "90%",
      marginBottom: "2vh",
      overflow: "auto",
      alignSelf: "center",
    }
  },
  checkoutButton: {
    width: "40%",
    height: "5vh",
    alignSelf: "flex-start",
    [theme.breakpoints.down("md")]: {
      width: "90%",
      alignSelf: "center",
    }
  },
};