import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { DomikiPage } from "./components/DomikiPage";
import { Home } from "./components/Home";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/domiki-page',
        element: <DomikiPage />
    },
    ...ApiAuthorzationRoutes
];

export default AppRoutes;
