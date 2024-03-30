import { createWebHashHistory, createRouter } from "vue-router";
import Login from "./pages/Login.vue";
import Home from "./pages/Home.vue";
import About from './pages/About.vue'
import Register from './pages/Register.vue'
import DefaultTemplateComponent from "./components/DefaultTemplateComponent.vue";
import TemplateExternalComponernt from './components/TemplateExternalComponernt.vue'

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
    component: TemplateExternalComponernt,
    path: "/login",
    name: "login",
    children : [
      {path : "/login", component:Login},
      {path : "/register", component:Register},
    ]
  },
  {
    path: "/register",
    name: "register",
    component: Register,
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;
