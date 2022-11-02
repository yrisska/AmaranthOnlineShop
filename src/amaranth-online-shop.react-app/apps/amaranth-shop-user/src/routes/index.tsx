import { Box, CircularProgress } from "@mui/material";
import { Suspense } from "react";
import { Route, Routes } from "react-router-dom";
import { commonRoutes } from "./commonRoutes";
import { privateRoutes } from "./privateRoutes";
import { PrivateRoute } from "@amaranth-online-shop.react-app/amaranth-shop-user-lib";

const AppRoutes = () => {

  const Spinner = (
    <Box
      component="div"
      display="flex"
      justifyContent="center"
      alignItems="center"
      height="100vh"
    >
      <CircularProgress />
    </Box>
  );

  return (
    <Suspense
      fallback={Spinner}
    >
      <Routes>
        {[...commonRoutes, ...privateRoutes].map((route, index) => (
          <Route
            path={route.path}
            key={`r_${index}_${route.path}`}
            element={route.isAuth ? (
              <PrivateRoute>{route.element}</PrivateRoute>
            ) :
              route.element
            }
          />
        ))}
      </Routes>
    </Suspense>
  );
};
export default AppRoutes;