import { AppBar, Box, Grid, IconButton, InputBase, Paper, Toolbar, useMediaQuery, useTheme } from "@mui/material";
import MenuDrawer from "../MenuDrawer/MenuDrawer";
import { createSearchParams, Link, useLocation, useNavigate } from "react-router-dom";
import SpaOutlinedIcon from "@mui/icons-material/SpaOutlined";
import { AppRouteEnum, PublicRouteEnum } from "../../../types";
import ShoppingCartOutlinedIcon from "@mui/icons-material/ShoppingCartOutlined";
import { headerStyles } from "./Header.styles";
import { useSelector } from "react-redux";
import { selectCartTotalQuantity } from "@amaranth-online-shop.react-app/redux";
import PersonOutlineOutlinedIcon from "@mui/icons-material/PersonOutlineOutlined";
import { ChangeEvent, FormEvent, useState } from "react";
import Cart from "../../modals/Cart/Cart";
import UserMenu from "../UserMenu/UserMenu";
import SearchIcon from "@mui/icons-material/Search";

const Header = () => {

  const theme = useTheme();
  const isDownLg = useMediaQuery(theme.breakpoints.down("lg"));
  const isDownMd = useMediaQuery(theme.breakpoints.down("md"));
  const location = useLocation();
  const navigate = useNavigate();

  const [search, setSearch] = useState("");

  const [cartIsOpen, setCartIsOpen] = useState(false);
  const cartTotalQuantity = useSelector(selectCartTotalQuantity);

  const [userMenuAnchor, setUserMenuAnchor] = useState<null | HTMLElement>(null);

  const searchChangeHandler = (event: ChangeEvent<HTMLInputElement>) => {
    setSearch(event.target.value);
  };

  const submitSearchHandler = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    navigate({
      pathname: AppRouteEnum.SHOP,
      search: createSearchParams({
        name: search
      }).toString()
    });
  };

  const openUserMenuHandler = (event: React.MouseEvent<HTMLElement>) => {
    setUserMenuAnchor(event.currentTarget);
  };

  const closeUserMenuHandler = () => {
    setUserMenuAnchor(null);
  };

  const openCartEventHandler = () => {
    setCartIsOpen(true);
  };

  const closeCartEventHandler = () => {
    setCartIsOpen(false);
  };

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
                  {Object.keys(PublicRouteEnum).map((page, index) => (
                    <Grid
                      item
                      xs={1}
                      key={index}
                    >
                      <Grid
                        item
                        component={Link}
                        to={PublicRouteEnum[page as keyof typeof PublicRouteEnum]}
                        sx={{
                          textDecoration: "none",
                          color: PublicRouteEnum[page as keyof typeof PublicRouteEnum] === location.pathname ?
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
                lg={3}
                xs={8}
                container
              >
                <Paper
                  component="form"
                  sx={{ p: "2px 4px", display: "flex", alignItems: "center", width: "100%" }}
                  onSubmit={submitSearchHandler}
                >
                  <InputBase
                    sx={{ ml: 1, flex: 1 }}
                    value={search}
                    onChange={searchChangeHandler}
                    placeholder="Search for products"
                    inputProps={{ "aria-label": "search for products" }}
                  />
                  <IconButton
                    type="submit"
                    sx={{ p: "10px" }}
                    aria-label="search"
                  >
                    <SearchIcon />
                  </IconButton>
                </Paper>
              </Grid>
              <Grid
                container
                justifyContent="space-evenly"
                item
                md={1.5}
                xs={2}
              >
                {!isDownMd &&
                  <>
                    <IconButton
                      aria-label="user menu"
                      onClick={openUserMenuHandler}
                    >
                      <PersonOutlineOutlinedIcon style={{ scale: "1.6" }} />
                    </IconButton>
                    {userMenuAnchor &&
                      <UserMenu
                        anchorEl={userMenuAnchor}
                        handleClose={closeUserMenuHandler}
                      />
                    }
                  </>
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