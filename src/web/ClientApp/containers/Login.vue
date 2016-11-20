<template>
    <div class="col-sm-4 col-sm-offset-4">
        <h2>Log In</h2>
        <p>Log in to your account to get some great quotes.</p>
        <div class="alert alert-danger" v-if="error">
            <p>{{ error }}</p>
        </div>
        <div class="form-group">
            <input type="text"
                   class="form-control"
                   placeholder="Enter your username"
                   v-model="credentials.username">
        </div>
        <div class="form-group">
            <input type="password"
                   class="form-control"
                   placeholder="Enter your password"
                   v-model="credentials.password">
        </div>
        <button class="btn btn-primary" @click="submit()">Access</button>
    </div>
</template>

<script>
  import { mapGetters, mapActions } from 'vuex'
    const isBrowser = typeof window !== 'undefined';
  
  export default {
    data() {
      return {
        credentials: {
          username: '',
          password: ''
        },
        error: '',
        returnUrl: isBrowser ? document.referrer : '/'
      }
    },    
    computed: mapGetters(['user']),
    methods: {
      ...mapActions(['login']),
      submit() {
          var credentials = {
              username: this.credentials.username,
              password: this.credentials.password
          }

          
        // We need to pass the component's this context
          // to properly make use of http in the auth service
          var vm = this;
          this.login(credentials).then(() => {
              vm.$router.go(window.history.back());
          });
      }
    }
  }
</script>