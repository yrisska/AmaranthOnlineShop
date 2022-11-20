// eslint-disable-next-line @typescript-eslint/no-unused-vars

import { environment } from "../environments/environment";
import { CssBaseline } from "@mui/material";
import { Auth0Provider } from "@auth0/auth0-react";
import { AdminComponent } from "../admin/AdminComponent";

export function App() {

  return (
    <Auth0Provider
      domain={environment.auth0Domain}
      clientId={environment.auth0ClientId}
      audience={environment.auth0Audience}
      redirectUri={window.location.origin}
      useRefreshTokens={true}
      cacheLocation="localstorage"
    >
      <CssBaseline />
      <AdminComponent />
    </Auth0Provider>
  );
}

export default App;
