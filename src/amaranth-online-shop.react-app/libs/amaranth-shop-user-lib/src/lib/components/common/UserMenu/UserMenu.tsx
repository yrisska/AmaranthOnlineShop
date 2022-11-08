import { useAuth0 } from "@auth0/auth0-react";
import { Avatar, Divider, ListItemIcon, Menu, MenuItem, Typography } from "@mui/material";
import { FC, useCallback } from "react";
import { Link as RouterLink } from "react-router-dom";
import LoginButton from "../LoginButton/LoginButton";
import { UserMenuProps } from "./UserMenu.types";
import LoginIcon from "@mui/icons-material/Login";
import LogoutIcon from "@mui/icons-material/Logout";
import ListAltIcon from "@mui/icons-material/ListAlt";
import ManageAccountsIcon from "@mui/icons-material/ManageAccounts";
import { AppRouteEnum } from "../../../types";

const UserMenu: FC<UserMenuProps> = ({
  anchorEl,
  handleClose
}) => {
  const { loginWithRedirect, user, isAuthenticated, isLoading, logout } = useAuth0();

  const handleLogin = useCallback(() => {
    loginWithRedirect({
      appState: {
        returnTo: `${window.location.pathname}${window.location.search}`,
      },
    });
  }, []);

  return (
    <Menu
      id=""
      anchorEl={anchorEl}
      keepMounted
      open={true}
      onClose={handleClose}
    >
      {!isAuthenticated ?
        <MenuItem
          onClick={handleLogin}
        >
          <ListItemIcon>
            <LoginIcon fontSize="small" />
          </ListItemIcon>
          Login
        </MenuItem>
        :
        <>
          {
            user &&
            <>
              <MenuItem
                sx={{ columnGap: "2vh" }}
              >
                {user.picture ?
                  <Avatar src={user.picture} />
                  :
                  <Avatar children={user.name?.at(0) || "A"} />
                }
                <Typography
                  variant="body1"
                  color="initial"
                >
                  {user.given_name || "Anonymous"}
                </Typography>
              </MenuItem>
              <Divider />
              <MenuItem
                component={RouterLink}
                disabled
                to="/account"
              >
                <ListItemIcon>
                  <ManageAccountsIcon fontSize="small" />
                </ListItemIcon>
                Account
              </MenuItem>
              <MenuItem
                component={RouterLink}
                to={AppRouteEnum.ORDERS}
              >
                <ListItemIcon>
                  <ListAltIcon fontSize="small" />
                </ListItemIcon>
                My orders
              </MenuItem>
              <MenuItem onClick={() => logout({ returnTo: window.location.origin })}>
                <ListItemIcon>
                  <LogoutIcon fontSize="small" />
                </ListItemIcon>
                Logout
              </MenuItem>
            </>
          }
        </>
      }
    </Menu>
  );
};

export default UserMenu;