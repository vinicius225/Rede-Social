import { createMemoryHistory, createRouter } from "vue-router";
import Login from "./pages/Login.vue";
import Home from "./pages/Home.vue";
import About from './pages/About.vue'
import DefaultTemplateComponent from "./components/DefaultTemplateComponent.vue";

const routes = [
  {
    path: "/",
    name: "home",
    component: DefaultTemplateComponent,
    children: [
      { path: "/", component: Home },
      { path: "/about", component: About },
    ],
  },
  {
    path: "/login",
    name: "login",
    component: Login,
  },
];

const router = createRouter({
  history: createMemoryHistory(),
  routes,
});

export default router;
