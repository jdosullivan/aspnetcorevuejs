<template>
    <div class="col-sm-4 col-sm-offset-4">
        <h2>Register</h2>
        <div class="alert alert-danger" v-if="error">
            <p>{{ error }}</p>
        </div>
        <div class="form-group">
            <input type="text"
                   class="form-control"
                   placeholder="Enter your name"
                   v-model="credentials.name">
        </div>
        <div class="form-group">
            <input type="text"
                   class="form-control"
                   placeholder="Enter your email"
                   v-model="credentials.email">
        </div>
        <div class="form-group">
            <input type="password"
                   class="form-control"
                   placeholder="Enter your password"
                   v-model="credentials.password">
        </div>
        <div class="form-group">
            <input type="password"
                   class="form-control"
                   placeholder="Confirm your password"
                   v-model="credentials.confirmpassword">
        </div>
        <button class="btn btn-primary" @click="submit()">Access</button>
    </div>
</template>

<script>
  import { mapGetters, mapActions } from 'vuex'
  
  export default {
    data() {
      return {
        credentials: {
            name: '',
            email: '',
          password: '',
          confirmpassword: ''
        },
        error: ''
      }
    },    
    computed: mapGetters(['user']),
    methods: {
        ...mapActions(['signup']),
      submit() {
          var credentials = {
              name: this.credentials.name,
              email: this.credentials.email,
              password: this.credentials.password,
              confirmpassword: this.credentials.confirmpassword
          }
        // We need to pass the component's this context
        // to properly make use of http in the auth service
        this.signup(credentials, 'secretquote')
      }
    }
  }
</script>