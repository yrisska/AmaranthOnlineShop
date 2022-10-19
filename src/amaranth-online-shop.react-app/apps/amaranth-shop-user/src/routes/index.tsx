import { Box, CircularProgress } from '@mui/material';
import { Suspense } from 'react'
import { Route, Routes } from 'react-router-dom';
import { commonRoutes } from './commonRoutes';

const AppRoutes = () => {
    return (
        <Suspense
            fallback={
                <Box
                    component="div"
                    display="flex"
                    justifyContent="center"
                    alignItems="center"
                    height="100vh"
                >
                    <CircularProgress />
                </Box>
            }
        >
            <Routes>
                {commonRoutes.map((route, index) => (
                    <Route
                        path={route.path}
                        key={`r_${index}_${route.path}`}
                        element={route.element}
                    />
                ))}
            </Routes>
        </Suspense>
    )
}
export default AppRoutes;