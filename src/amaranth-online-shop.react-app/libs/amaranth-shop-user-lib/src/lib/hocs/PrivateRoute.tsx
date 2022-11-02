import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";
import { FC, PropsWithChildren, ComponentType } from "react";
import { Navigate } from "react-router-dom";
import { AppRouteEnum } from "../types";

export const PrivateRoute: FC<PropsWithChildren> = ({
  children
}) => {

  const { isAuthenticated, user, isLoading } = useAuth0();

  if (isLoading) {
    return (
      <></>
    );
  }
  if (!isAuthenticated || !user) {
    return (

      <Navigate
        to={AppRouteEnum.HOME}
        replace={true}
      />
    );
  }
  return <>{children}</>;
};

export default PrivateRoute;