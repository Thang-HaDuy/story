'use client';

import Box from '@mui/material/Box';
import { Swiper, SwiperSlide } from 'swiper/react';
import { Pagination } from 'swiper/modules';
import SlideItem, { IStep } from './SlideItem';

const SlideAnimeTop = () => {
    const tutorialSteps: IStep[] = [
        {
            label: 'San Francisco 10',
            imgPath: '/slide.webp',
            name: 'Lúc Đó, Tôi Đã Chuyển Sinh Thành Slime Mùa 3',
            detail: 'Anh thanh niên dân đen bất tài thấp hèn vô dụng trước khi chết đã ước được trở thànhbậc thầy ma pháp, không...',
            episode: 5,
            author: 'East Fish Studio',
            rating: 4.3,
            className: 'hoverEffect31',
            categories: ['Drama', 'Ecchi', 'Fantasy'],
            info: {
                rating: 44,
                date: '1025-4-3',
                quality: 'HD',
                period: '4/4',
                color: '#fff',
            },
        },
        {
            label: 'San Francisco 10',
            imgPath: '/slide.webp',
            name: 'Lúc Đó, Tôi Đã Chuyển Sinh Thành Slime Mùa 3',
            detail: 'Anh thanh niên dân đen bất tài thấp hèn vô dụng trước khi chết đã ước được trở thànhbậc thầy ma pháp, không...',
            episode: 5,
            author: 'East Fish Studio',
            rating: 4.3,
            className: 'hoverEffect31',
            categories: ['Drama', 'Ecchi', 'Fantasy'],
            info: {
                rating: 44,
                date: '1025-4-3',
                quality: 'HD',
                period: '4/4',
                color: '#fff',
            },
        },
        {
            label: 'San Francisco 10',
            imgPath: '/slide.webp',
            name: 'Lúc Đó, Tôi Đã Chuyển Sinh Thành Slime Mùa 3',
            detail: 'Anh thanh niên dân đen bất tài thấp hèn vô dụng trước khi chết đã ước được trở thànhbậc thầy ma pháp, không...',
            episode: 5,
            author: 'East Fish Studio',
            rating: 4.3,
            className: 'hoverEffect31',
            categories: ['Drama', 'Ecchi', 'Fantasy'],
            info: {
                rating: 44,
                date: '1025-4-3',
                quality: 'HD',
                period: '4/4',
                color: '#fff',
            },
        },
        {
            label: 'San Francisco 10',
            imgPath: '/slide.webp',
            name: 'Lúc Đó, Tôi Đã Chuyển Sinh Thành Slime Mùa 3',
            detail: 'Anh thanh niên dân đen bất tài thấp hèn vô dụng trước khi chết đã ước được trở thànhbậc thầy ma pháp, không...',
            episode: 5,
            author: 'East Fish Studio',
            rating: 4.3,
            className: 'hoverEffect31',
            categories: ['Drama', 'Ecchi', 'Fantasy'],
            info: {
                rating: 44,
                date: '1025-4-3',
                quality: 'HD',
                period: '4/4',
                color: '#fff',
            },
        },
    ];

    return (
        <Box
            component={Swiper}
            slidesPerView={1}
            modules={[Pagination]}
            pagination={{ clickable: true }}
            spaceBetween={0}
            sx={{
                '& .swiper-pagination': {
                    textAlign: 'end',
                    paddingRight: '15px',
                    paddingBottom: '8px',
                },
                '& .swiper-pagination-bullet': {
                    width: '10px',
                    height: '10px',
                    backgroundColor: '#fff',
                    opacity: 0.2,
                    borderRadius: '50%',
                    margin: '0 5px',
                },
                '& .swiper-pagination-bullet-active': {
                    backgroundColor: '#b71c1c',
                    opacity: 1,
                },
                marginBottom: '20px',
            }}
        >
            {tutorialSteps.map((step, index) => (
                <SwiperSlide key={index}>
                    <SlideItem step={step} />
                </SwiperSlide>
            ))}
        </Box>
    );
};

export default SlideAnimeTop;
