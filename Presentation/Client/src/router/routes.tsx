import { createBrowserRouter, Navigate } from "react-router";
import App from "../layout/App";
import NotFound from "../errors/NotFound";
import HomePage from "../features/HomePage";
import ServerError from "../errors/ServerError";
export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "",
                element: <HomePage />
            },
            {
                path: "not-found",
                element: <NotFound />
            },
            {
                path: "server-error",
                element: <ServerError />
            },
            {
                path: "*",
                element: <Navigate to="/not-found" />
            }
        ]
    }
]);