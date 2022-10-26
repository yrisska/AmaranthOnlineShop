import { GridSize } from "@mui/material";
import { GridDirection, ResponsiveStyleValue } from "@mui/system";

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
  deleteAllButtonContainer: {
    item: true,
    container: true,
    xs: 12 as GridSize,
    justifyContent: "flex-end",
  },
  cartItemContainer: {
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
};