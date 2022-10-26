import { AppBar, Box, Grid, IconButton, Toolbar, useMediaQuery, useTheme } from "@mui/material";
import MenuDrawer from "../MenuDrawer/MenuDrawer";
import { Link, useLocation } from "react-router-dom";
import SpaOutlinedIcon from "@mui/icons-material/SpaOutlined";
import { AppRouteEnum } from "../../../types";
import ShoppingCartOutlinedIcon from "@mui/icons-material/ShoppingCartOutlined";
import { headerStyles } from "./Header.styles";
import { useSelector } from "react-redux";
import { selectCartTotalQuantity } from "@amaranth-online-shop.react-app/redux";
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";
import { useCallback, useState } from "react";
import Cart from "../Cart/Cart";

const Header = () => {

  const theme = useTheme();
  const isDownLg = useMediaQuery(theme.breakpoints.down("lg"));
  const isDownMd = useMediaQuery(theme.breakpoints.down("md"));
  const location = useLocation();

  const [cartIsOpen, setCartIsOpen] = useState(false);
  const cartTotalQuantity = useSelector(selectCartTotalQuantity);

  const openCartEventHandler = useCallback(() => {
    setCartIsOpen(true);
  }, []);

  const closeCartEventHandler = useCallback(() => {
    setCartIsOpen(false);
  }, []);

  return (
    <>
      <AppBar
        component="nav"
        sx={{
          background: theme.palette.primary.light,
          position: "fixed",
          top: "0",
        }}
      >
        <Toolbar>
          <Grid
            container
            direction="row"
            fontSize="1.5rem"
            justifyContent="center"
            color={theme.palette.primary.contrastText}
          >
            <Grid
              container
              item
              lg={10}
              justifyContent="space-between"
              alignItems="center"
            >
              {!!isDownLg &&
                <Grid
                  item
                  xs={1}
                >
                  <MenuDrawer />
                </Grid>
              }
              {!isDownMd &&
                <Grid
                  item
                  xs={1}
                  container
                  justifyContent="center"
                >
                  <IconButton
                    aria-label=""
                    href={AppRouteEnum.HOME}
                  >
                    <SpaOutlinedIcon sx={{ scale: "1.6", color: "inherit" }} />
                  </IconButton>
                </Grid>
              }
              {!isDownLg &&
                <Grid
                  container
                  item
                  lg={3}
                  md={3}
                  justifyContent="space-evenly"
                >
                  {Object.keys(AppRouteEnum).map((page, index) => (
                    <Grid
                      item
                      xs={1}
                      key={index}
                    >
                      <Grid
                        item
                        component={Link}
                        to={AppRouteEnum[page as keyof typeof AppRouteEnum]}
                        sx={{
                          textDecoration: "none",
                          color: AppRouteEnum[page as keyof typeof AppRouteEnum] === location.pathname ?
                            theme.palette.primary.main : theme.palette.primary.contrastText,
                          "&: hover": {
                            color: theme.palette.primary.dark
                          }
                        }}
                      >
                        {page}
                      </Grid>
                    </Grid>
                  ))}
                </Grid>
              }
              <Grid
                item
                lg={4}
                md={4}
                xs={4}
              >

              </Grid>
              <Grid
                container
                justifyContent="space-evenly"
                item
                md={2}
                xs={3}
              >
                {!isDownMd &&
                  <IconButton
                    aria-label=""
                    onClick={() => 1}
                  >
                    <PersonOutlineOutlinedIcon style={{ scale: "1.6" }} />
                  </IconButton>
                }
                <Grid
                  item
                  md={6}
                  xs={12}
                  container
                  justifyContent={isDownLg ? "flex-end" : "center"}
                >
                  <IconButton
                    aria-label="Cart"
                    onClick={openCartEventHandler}
                  >
                    <ShoppingCartOutlinedIcon style={{ scale: "1.5" }} />
                  </IconButton>
                  {
                    !!cartTotalQuantity &&
                    <Box sx={headerStyles.cartItems}>
                      {cartTotalQuantity}
                    </Box>
                  }
                </Grid>

              </Grid>
            </Grid>

          </Grid>
        </Toolbar>
      </AppBar>
      <Box
        sx={{
          height: "10vh"
        }}
      />
      {
        cartIsOpen && <Cart handleClose={closeCartEventHandler} />
      }
    </>

  );
};

export default Header;