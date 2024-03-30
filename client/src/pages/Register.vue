<script setup>
import { reactive } from 'vue';
import { RouterLink } from 'vue-router';
const formState = reactive({
    username: '',
    password: '',
    remember: true,
});
</script>

<template>
    <a-row>
        <a-col :span="24" class="logo">
            <h1>Logo</h1>
        </a-col>
    </a-row>
    <div class="form">
        <a-form :model="formState" name="basic" :label-col="{ span: 8 }" :wrapper-col="{ span: 24 }"
            autocomplete="off" @finish="onFinish" @finishFailed="onFinishFailed">
            <a-row>
                <a-col :xs="20" :sm="16" :md="12" :lg="20">
                    <a-form-item label="Username" name="username"
                        :rules="[{ required: true, message: 'Please input your username!' }]">
                        <a-input v-model:value="formState.username" />
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row>
                <a-col :xs="20" :sm="16" :md="12" :lg="20">
                    <a-form-item label="Password" name="password"
                        :rules="[{ required: true, message: 'Please input your password!' }]">
                        <a-input-password v-model:value="formState.password" />
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row style="display: flex; justify-content: center;">
                <a-col :span="16">
                    <a-form-item>
                        <a-button type="primary" class="button" html-type="submit">Logar</a-button>
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row style="display: flex; justify-content: center;">
                <a-col :span="16">
                    <a-form-item>
                        <RouterLink to="/register">
                            <a-button type="default" class="button" html-type="submit">Cadastrar</a-button>
                        </RouterLink>
                    </a-form-item>
                </a-col>
            </a-row>
        </a-form>
    </div>

</template>

<style scoped>

</style>