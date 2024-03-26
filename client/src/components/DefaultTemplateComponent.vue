<script setup>
import { RouterView } from 'vue-router';
import { ref } from 'vue';
const selectedKeys = ref(['2']);
</script>
<template>
    <div id="default_container">
    <a-layout >
      <a-layout-header :style="{ position: 'fixed', zIndex: 1, width: '100%' }">
        <div class="logo" />
        <didvs class="logo">
            imagem
        </didvs>
        <a-menu
          v-model:selectedKeys="selectedKeys"
          theme="dark"
          mode="horizontal"
          :style="{ lineHeight: '64px' }"
        >
        <didv class="menu">
          <a-menu-item key="1">nav 1</a-menu-item>
          <a-menu-item key="2">nav 2</a-menu-item>
          <a-menu-item key="3">nav 3</a-menu-item>
        </didv>
          <div class="preferencs">
            <a-dropdown :trigger="['click']">
                <a class="ant-dropdown-link" @click.prevent>
                  Click me
                  <DownOutlined />
                </a>
                <template #overlay>
                  <a-menu>
                    <a-menu-item key="0">
                      <a href="http://www.alipay.com/">1st menu item</a>
                    </a-menu-item>
                    <a-menu-item key="1">
                      <a href="http://www.taobao.com/">2nd menu item</a>
                    </a-menu-item>
                    <a-menu-divider />
                    <a-menu-item key="3">3rd menu item</a-menu-item>
                  </a-menu>
                </template>
              </a-dropdown>

          </div>
        </a-menu>
      </a-layout-header>
      <a-layout-content :style="{ padding: '0 50px', marginTop: '64px' }">
        <a-breadcrumb :style="{ margin: '16px 0' }">
<span>Nome da Tela</span>
        </a-breadcrumb>
        <div :style="{ background: '#fff', padding: '24px', minHeight: 'calc(100vh - 128px)' }">
            <RouterView/>
        </div>
      </a-layout-content>
      <a-layout-footer :style="{ textAlign: 'center', position: 'fixed', bottom: 0, width: '100%', zIndex: 1 }">
        Vinicius Andrade ©
      </a-layout-footer>
    </a-layout>
</div>
  </template>
  <style scoped>
.preferencs{
    right: 0;
    position: fixed;
    z-index: 11;
}
.menu {
margin: auto;
}
.logo{
position: fixed;
}
  </style>