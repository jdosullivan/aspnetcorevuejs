<template>
    <div :id="'group-' + group.id" class="group mix col-lg-3 col-md-6" style="display: inline-block;">
        <div class="be-post">
            <router-link :to="'/group/' + group.id" class="be-img-block">
                <img v-bind:src="group.img" alt="omg">
            </router-link>
            <router-link :to="'/group/' + group.id"  class="be-post-title">{{ group.name }}</router-link>
            <span v-for="tag in group.tags">
                <a href="/tag1" class="be-post-tag">{{ tag }}</a>
            </span>
            <div class="author-post">
                <img v-bind:src="group.owner.avatarUrl" alt="" class="ava-author">
                <span>by <a v-bind:href="'/' + group.owner.name">{{group.owner.name}}</a></span>
            </div>
            <div class="info-block">
                <span><i class="fa fa-thumbs-o-up"></i> {{ group.memberCount }}</span>
                <span><i class="fa fa-comment-o"></i> {{ group.eventCount }}</span>
            </div>
        </div>
    </div>
</template>


<script>
      import { mapActions } from 'vuex'
      export default {
        props: ['group']
      }
</script>