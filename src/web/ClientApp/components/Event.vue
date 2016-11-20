<template>
    <div>
        <div class="blog-post">
            <div class="row">
                <div class="col-xs-12 col-sm-7">
                    <a class="post-preview post-image" :href="url">
                        <img class="img-responsive img-full" :src="image" alt="">
                    </a>
                </div>
                <div class="col-xs-12 col-sm-5">
                    <div class="post-desc">
                        <div class="post-category">{{tags}}</div>
                        <a class="post-label" :href="url">{{name}}</a>
                        <div class="post-text">{{description}}</div>
                        <div class="creator-post">
                            <img :src="creator.avatarUrl" alt="" class="ava-creator">
                            <span>by <a :href="creator.profileUrl">{{creator.name}}</a></span>
                        </div>
                        <div class="info-block">
                            <span><i class="fa fa-thumbs-o-up"></i> 360</span>
                            <span><i class="fa fa-eye"></i> 789</span>
                            <span><i class="fa fa-comment-o"></i> 20</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="blog-post">
            <div class="row">
                <div class="col-xs-12 col-sm-7">
                    <div class="post-preview">
                        <div class="swiper-container swiper-swiper-unique-id-0 initialized" data-autoplay="0" data-loop="1" data-speed="500" data-center="0" data-slides-per-view="1" id="swiper-unique-id-0">
                            <div class="swiper-wrapper" style="width: 3260px; transform: translate3d(-652px, 0px, 0px); transition-duration: 0s; height: 390px;">
                                <div class="swiper-slide swiper-slide-duplicate" data-val="2" style="width: 652px; height: 390px;">
                                    <img class="img-responsive img-full" src="../assets/images/blog_1.jpg" alt="">
                                </div>
                                <div class="swiper-slide active swiper-slide-visible swiper-slide-active" data-val="0" style="width: 652px; height: 390px;">
                                    <img class="img-responsive img-full" src="../assets/images/blog_2.jpg" alt="">
                                </div>
                                <div class="swiper-slide" data-val="1" style="width: 652px; height: 390px;">
                                    <img class="img-responsive img-full" src="../assets/images/blog_3.jpg" alt="">
                                </div>
                                <div class="swiper-slide" data-val="2" style="width: 652px; height: 390px;">
                                    <img class="img-responsive img-full" src="../assets/images/blog_1.jpg" alt="">
                                </div>
                                <div class="swiper-slide active swiper-slide-duplicate" data-val="0" style="width: 652px; height: 390px;">
                                    <img class="img-responsive img-full" src="../assets/images/blog_2.jpg" alt="">
                                </div>
                            </div>
                            <div class="pagination hidden pagination-swiper-unique-id-0"><span class="swiper-pagination-switch swiper-visible-switch swiper-active-switch"></span><span class="swiper-pagination-switch"></span><span class="swiper-pagination-switch"></span></div>
                            <div class="swiper-arrow-left type-2 type-3"></div>
                            <div class="swiper-arrow-right type-2 type-3"></div>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-5">
                    <div class="post-desc">
                        <div class="post-category">Art, Street, Drawing</div>
                        <a class="post-label" href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail.html">Street Art on the London big wall</a>
                        <div class="post-text">Morbi efficitur feugiat erat a efficitur. Donec interdum, nunc ac elementum auctor, dui nisl placerat odio, eget sagittis sem neque venenatis libero. Vestibulum pharetra sollicitudin urna nec eleifend.Suspendisse id augue ut nunc vestibulum euismod. Donec a libero ut lectus ullamcorper rhoncus vel quis erat. Nunc ornare sed dolor sed mattis.</div>
                        <div class="creator-post">
                            <img src="../assets/images/a1.png" alt="" class="ava-creator">
                            <span>by <a href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail-2.html">Hoang Nguyen</a>, April 23, 2015</span>
                        </div>
                        <div class="info-block">
                            <span><i class="fa fa-thumbs-o-up"></i> 360</span>
                            <span><i class="fa fa-eye"></i> 789</span>
                            <span><i class="fa fa-comment-o"></i> 20</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="blog-post">
            <div class="row">
                <div class="col-xs-12 col-sm-7">
                    <a class="post-preview post-image" href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail.html"><img class="img-responsive img-full" src="../assets/images/blog_3.jpg" alt=""></a>
                </div>
                <div class="col-xs-12 col-sm-5">
                    <div class="post-desc">
                        <div class="post-category">News, People, Ideas</div>
                        <a class="post-label" href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail.html">Gorge Newman has an idea</a>
                        <div class="post-text">Suspendisse ultricies erat sit amet orci scelerisque, nec sagittis libero iaculis. Curabitur a nulla ut velit imperdiet efficitur eget at leo. Proin nec condimentum risus. Phasellus eget ipsum non mi sodales commodo. Vivamus tincidunt arcu eget libero lacinia, ut sollicitudin nisl accumsan. lacus. Sed venenatis enim massa, ac rhoncus ex iaculis at. Ut tempor</div>
                        <div class="creator-post">
                            <img src="../assets/images/a1.png" alt="" class="ava-creator">
                            <span>by <a href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail-2.html">Hoang Nguyen</a>, April 23, 2015</span>
                        </div>
                        <div class="info-block">
                            <span><i class="fa fa-thumbs-o-up"></i> 360</span>
                            <span><i class="fa fa-eye"></i> 789</span>
                            <span><i class="fa fa-comment-o"></i> 20</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="blog-post">
            <div class="row">
                <div class="col-xs-12 col-sm-7">
                    <div class="post-preview embed-responsive embed-responsive-16by9">
                        <iframe class="embed-responsive-item" src="../assets/images/80414492.html"></iframe>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-5">
                    <div class="post-desc">
                        <div class="post-category">Video, Creative</div>
                        <a class="post-label" href="http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail.html">Wonderfull pasterize video play</a>
                        <div class="post-text">Vestibulum molestie odio erat, et feugiat lorem euismod ut. Aliquam in orci sem. Aenean mauris enim, feugiat non iaculis vel, efficitur eget nisl. Nunc tristique hendrerit dignissim. Suspendisse sed facilisis dui. Suspendisse nisl dui, posuere quis euismod sed, faucibus id odio. Lorem ipsum dolor</div>
                        <div class="creator-post">
                            <img :src="creator.avatarUrl" alt="" class="ava-creator">
                            <span>by <a :href="creator.profileUrl">Hoang Nguyen</a>, April 23, 2015</span>
                        </div>
                        <div class="info-block">
                            <span><i class="fa fa-thumbs-o-up"></i> {{rsvpCount}}</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        props: {
            name: {
                type: String
            },
            description: {
                type: String
            },
            url: {
                type: String,
                default:  "http://demo.nrgthemes.com/projects/nrgnetwork/blog-detail.html"
            },
            rsvpCount: {
                type: Number,
                default: 67
            },
            creator: {
                type: Object,
                default:  function () { return { name: 'Hoang Nguyen', avatarUrl: require('../assets/images/a1.png'), profileUrl: '/profile/user' } }
            }            
        },
        data() {
            return {
                image: require("../assets/images/blog_1.jpg")
            };
        },
        computed:{
            tags() { 
                return 'Concepts, Drawing'; 
            }
        }
    }
</script>