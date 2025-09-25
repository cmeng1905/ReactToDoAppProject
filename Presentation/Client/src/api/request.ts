import axios, { AxiosError, type AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { router } from "../router/routes";

axios.defaults.baseURL = "http://localhost:5042/api/";
axios.defaults.withCredentials = true;

axios.interceptors.response.use(response => {
    return response;
}, (error: AxiosError) => {
    if (!error.response) {
        toast.error("Server Error");
        return
    }
    const { data, status } = error.response as AxiosResponse;
    switch (status) {
        case 400:
            if (data.errors) {
                const modelErrors: string[] = [];
                for (const key in data.errors) {
                    modelErrors.push(data.errors[key]);
                }
                throw modelErrors;
            }
            toast.error(data.title); break;
        case 401:
            toast.error(data.title); break;
        case 404:
            router.navigate("/not-found"); break;
        case 500:
            router.navigate("/server-error", { state: { error: data, status: status } }); break;
        default:
            break;
    }
    return Promise.reject(error.response);
});

const queries = {
    get: (url: string) => axios.get(url).then((response: AxiosResponse) => response.data),
    post: (url: string, body: {}) => axios.post(url, body).then((response: AxiosResponse) => response.data),
    put: (url: string, body: {}) => axios.put(url, body).then((response: AxiosResponse) => response.data),
    delete: (url: string) => axios.delete(url).then((response: AxiosResponse) => response.data),
}

const Category = {
    list: () => queries.get('categories'),
    details: (id: number) => queries.get(`categories/${id}`)
}

const ToDo = {
    get: () => queries.get('todos'),
    getById: (id: number) => queries.get(`todos/${id}`),
    addItem: (title: string, description: string) => queries.post('todos/add-todo', { title, description }),
    deleteItem: (id: number) => queries.delete(`todos/${id}`),
    updateItem: (id: number, title: string, description: string) => queries.put(`todos/update-todo/${id}`, { title, description })
}

const requests = {
    Category,
    ToDo
}

export default requests