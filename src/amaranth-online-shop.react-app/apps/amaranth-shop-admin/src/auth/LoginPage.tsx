import { useAuth0 } from "@auth0/auth0-react";
import { Box, CircularProgress } from "@mui/material";
import { useEffect } from "react";
import { useLogin, useNotify } from "react-admin";

const LoginPage = () => {

  const { loginWithRedirect } = useAuth0();

  const notify = useNotify();
  const login = useLogin();

  useEffect(() => {
    loginWithRedirect()
      .then(() => login(undefined))
      .catch(() => notify("Please login via admin account in order to access resource"));
  }, []);

  return (
    <Box
      component="div"
      display="flex"
      justifyContent="center"
      alignItems="center"
      height="100vh"
    >
      < CircularProgress />
    </Box >
  );
};

export default LoginPage;