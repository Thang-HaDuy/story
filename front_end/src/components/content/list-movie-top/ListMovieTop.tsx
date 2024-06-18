'use client';

import React, { useState } from 'react';
import { Swiper, SwiperSlide } from 'swiper/react'; // Import Swiper và SwiperSlide từ thư viện swiper/react
import 'swiper/swiper-bundle.css'; // Import CSS của Swiper
import IconButton from '@mui/material/IconButton'; // Import IconButton từ Material-UI
import Box from '@mui/material/Box'; // Import Box từ Material-UI
import KeyboardArrowRight from '@mui/icons-material/KeyboardArrowRight'; // Import KeyboardArrowRight từ Material-UI
import KeyboardArrowLeft from '@mui/icons-material/KeyboardArrowLeft'; // Import KeyboardArrowLeft từ Material-UI
import Link from 'next/link';
import Typography from '@mui/material/Typography';
import SelectHover from '@/components/ui/SelectHover';
import Rating from '@/components/ui/Rating';
import TotalEpisode from '@/components/ui/TotalEpisode';
import MovieItem from './item/MovieItem';
import PlayCircleOutlineIcon from '@mui/icons-material/PlayCircleOutline';

export interface TutorialStep {
    label: string;
    imgPath: string;
    text: string;
    episode: number;
    rating: number;
    className: string;
}

const ListMovieTop: React.FC = () => {
    const tutorialSteps: TutorialStep[] = [
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng Viên Dũng Giả Từ Cấp Độ Hai',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect31',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng Viên Dũng Giả Từ Cấp Độ Hai',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect32',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng Viên Dũng Giả Từ Cấp Độ Hai',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect33',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng Viên Dũng Giả Từ Cấp Độ Hai',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect34',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng Viên Dũng Giả Từ Cấp Độ Hai',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect35',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng Viên Dũng Giả Từ Cấp Độ Hai',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect36',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng Viên Dũng Giả Từ Cấp Độ Hai',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect37',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng Viên Dũng Giả Từ Cấp Độ Hai',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect38',
        },
        {
            label: 'San Francisco 10',
            imgPath: '/02yvy2ix.webp',
            text: 'Cuộc Sống Thảnh Thơi Tại Dị Giới Gian Lận Của Cựu Ứng Viên Dũng Giả Từ Cấp Độ Hai',
            episode: 5,
            rating: 4.3,
            className: 'hoverEffect39',
        },
    ];

    const breakpoints = {
        150: {
            slidesPerView: 2,
        },
        467: {
            slidesPerView: 4,
        },
        785: {
            slidesPerView: 6,
        },
        1005: {
            slidesPerView: 8,
        },
    };

    const [swiper, setSwiper] = useState<any>(null); // State để lưu trữ swiper instance

    const handleNext = () => {
        if (swiper) swiper.slideNext(); // Hàm xử lý khi nhấn nút Next
    };

    const handleBack = () => {
        if (swiper) swiper.slidePrev(); // Hàm xử lý khi nhấn nút Back
    };

    return (
        <Box sx={{ position: 'relative', maxWidth: '100%', flexGrow: 1 }}>
            <Box
                component={Swiper}
                sx={{ marginX: '-9.6px' }}
                onSwiper={setSwiper}
                breakpoints={breakpoints}
                loop={true}
            >
                {tutorialSteps.map((step, index) => (
                    <SwiperSlide key={index}>
                        <MovieItem step={step} />
                    </SwiperSlide>
                ))}
            </Box>

            <IconButton
                sx={{
                    position: 'absolute',
                    zIndex: '10',
                    height: '31.5px',
                    width: '25px',
                    borderRadius: 'inherit',
                    marginLeft: '-1.5px',
                    top: '50%',
                    left: 0,
                    transform: 'translateY(-50%)',
                    backgroundColor: '#f62f39',
                    '&:hover': { backgroundColor: '#f62f39' },
                }}
                size="small"
                onClick={handleBack}
            >
                <KeyboardArrowLeft />
            </IconButton>
            <IconButton
                sx={{
                    position: 'absolute',
                    zIndex: '10',
                    height: '31.5px',
                    width: '25px',
                    borderRadius: 'inherit',
                    marginRight: '-1.5px',
                    top: '50%',
                    right: 0,
                    transform: 'translateY(-50%)',
                    backgroundColor: '#f62f39',
                    '&:hover': { backgroundColor: '#f62f39' },
                }}
                size="small"
                onClick={handleNext}
            >
                <KeyboardArrowRight />
            </IconButton>
        </Box>
    );
};

export default ListMovieTop;

// <SwiperSlide key={index}>
//     <Box
//         component={Link}
//         href={'/'}
//         sx={{
//             '&:hover': {
//                 [`& .${step.className}`]: { display: 'flex' },
//             },
//         }}
//     >
//         <Box sx={{ marginX: '9.6px', position: 'relative' }}>
//             <Box
//                 component="img"
//                 sx={{
//                     maxHeight: '300px',
//                     width: '100%',
//                     display: 'block',
//                     overflow: 'hidden',
//                     objectFit: 'cover',
//                 }}
//                 src={step.imgPath}
//                 alt={step.label}
//             />
//             <Typography
//                 sx={{
//                     color: '#fff',
//                     zIndex: '5',
//                     position: 'absolute',
//                     bottom: '0px',
//                     left: '0',
//                     right: '0',
//                     padding: '10px',
//                     paddingTop: '50px',
//                     fontSize: '12px',
//                     fontWeight: '400',
//                     lineHeight: '16px',
//                     textAlign: 'center',
//                     background: 'linear-gradient(to bottom,rgba(0,0,0,0) 0,rgba(0,0,0,.65) 100%)',
//                 }}
//             >
//                 {step.text}
//             </Typography>
//             <TotalEpisode episode={step.episode} />
//             <Rating number={step.rating} />
//             <SelectHover className={step.className} />
//         </Box>
//     </Box>
// </SwiperSlide>
