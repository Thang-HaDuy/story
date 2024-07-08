'use client';

import TitelItem from '@/components/content/TitelItem';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import { useState } from 'react';
import AnimeUpdateItem, { IAnimeUpdateItem } from '@/components/content/anime-update/AnimeUpdateItem';

const NominatedAnime = () => {
    const items: IAnimeUpdateItem[] = [
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
            episode: 4,
            itemHover: {
                name: 'Isekai Suicide Squad',
                detail: 'Fable là một tay sát thủ lão luyện giỏi nhất trong lĩnh vực của mình. Tuy nhiên, anh ta đã giết rất nhiều người hai po grafile',
                author: ' asread., studio MOTHER ',
                categories: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                performer: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                info: {
                    rating: 3.2,
                    date: '2024-3-5',
                    quality: 'HD',
                    period: '3/6',
                    color: '#78909c',
                },
            },
        },
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
            episode: 4,
            itemHover: {
                name: 'Isekai Suicide Squad',
                detail: 'Fable là một tay sát thủ lão luyện giỏi nhất trong lĩnh vực của mình. Tuy nhiên, anh ta đã giết rất nhiều người hai po grafile',
                author: ' asread., studio MOTHER ',
                categories: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                performer: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                info: {
                    rating: 3.2,
                    date: '2024-3-5',
                    quality: 'HD',
                    period: '3/6',
                    color: '#78909c',
                },
            },
        },
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
            episode: 4,
            itemHover: {
                name: 'Isekai Suicide Squad',
                detail: 'Fable là một tay sát thủ lão luyện giỏi nhất trong lĩnh vực của mình. Tuy nhiên, anh ta đã giết rất nhiều người hai po grafile',
                author: ' asread., studio MOTHER ',
                categories: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                performer: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                info: {
                    rating: 3.2,
                    date: '2024-3-5',
                    quality: 'HD',
                    period: '3/6',
                    color: '#78909c',
                },
            },
        },
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
            episode: 4,
            itemHover: {
                name: 'Isekai Suicide Squad',
                detail: 'Fable là một tay sát thủ lão luyện giỏi nhất trong lĩnh vực của mình. Tuy nhiên, anh ta đã giết rất nhiều người hai po grafile',
                author: ' asread., studio MOTHER ',
                categories: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                performer: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                info: {
                    rating: 3.2,
                    date: '2024-3-5',
                    quality: 'HD',
                    period: '3/6',
                    color: '#78909c',
                },
            },
        },
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
            episode: 4,
            itemHover: {
                name: 'Isekai Suicide Squad',
                detail: 'Fable là một tay sát thủ lão luyện giỏi nhất trong lĩnh vực của mình. Tuy nhiên, anh ta đã giết rất nhiều người hai po grafile',
                author: ' asread., studio MOTHER ',
                categories: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                performer: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                info: {
                    rating: 3.2,
                    date: '2024-3-5',
                    quality: 'HD',
                    period: '3/6',
                    color: '#78909c',
                },
            },
        },
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
            episode: 4,
            itemHover: {
                name: 'Isekai Suicide Squad',
                detail: 'Fable là một tay sát thủ lão luyện giỏi nhất trong lĩnh vực của mình. Tuy nhiên, anh ta đã giết rất nhiều người hai po grafile',
                author: ' asread., studio MOTHER ',
                categories: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                performer: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                info: {
                    rating: 3.2,
                    date: '2024-3-5',
                    quality: 'HD',
                    period: '3/6',
                    color: '#78909c',
                },
            },
        },
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
            episode: 4,
            itemHover: {
                name: 'Isekai Suicide Squad',
                detail: 'Fable là một tay sát thủ lão luyện giỏi nhất trong lĩnh vực của mình. Tuy nhiên, anh ta đã giết rất nhiều người hai po grafile',
                author: ' asread., studio MOTHER ',
                categories: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                performer: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                info: {
                    rating: 3.2,
                    date: '2024-3-5',
                    quality: 'HD',
                    period: '3/6',
                    color: '#78909c',
                },
            },
        },
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
            episode: 4,
            itemHover: {
                name: 'Isekai Suicide Squad',
                detail: 'Fable là một tay sát thủ lão luyện giỏi nhất trong lĩnh vực của mình. Tuy nhiên, anh ta đã giết rất nhiều người hai po grafile',
                author: ' asread., studio MOTHER ',
                categories: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                performer: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                info: {
                    rating: 3.2,
                    date: '2024-3-5',
                    quality: 'HD',
                    period: '3/6',
                    color: '#78909c',
                },
            },
        },
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
            episode: 4,
            itemHover: {
                name: 'Isekai Suicide Squad',
                detail: 'Fable là một tay sát thủ lão luyện giỏi nhất trong lĩnh vực của mình. Tuy nhiên, anh ta đã giết rất nhiều người hai po grafile',
                author: ' asread., studio MOTHER ',
                categories: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                performer: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                info: {
                    rating: 3.2,
                    date: '2024-3-5',
                    quality: 'HD',
                    period: '3/6',
                    color: '#78909c',
                },
            },
        },
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
            episode: 4,
            itemHover: {
                name: 'Isekai Suicide Squad',
                detail: 'Fable là một tay sát thủ lão luyện giỏi nhất trong lĩnh vực của mình. Tuy nhiên, anh ta đã giết rất nhiều người hai po grafile',
                author: ' asread., studio MOTHER ',
                categories: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                performer: ['Harem', 'Fantasy', 'Adventure', 'Magic'],
                info: {
                    rating: 3.2,
                    date: '2024-3-5',
                    quality: 'HD',
                    period: '3/6',
                    color: '#78909c',
                },
            },
        },
    ];
    const buttonLabels = ['Xem nhiều hôm nay', 'Xem nhiều trong mùa', 'Yêu Thích', 'Tháng'];
    const [activeButton, setActiveButton] = useState<string | null>('Xem nhiều hôm nay');

    const handleButtonClick = (buttonLabel: string) => {
        setActiveButton(buttonLabel);
    };
    return (
        <TitelItem
            title="ĐỀ CỬ"
            childrenTitle={
                <Box>
                    {buttonLabels.map((label) => (
                        <Button
                            key={label}
                            onClick={() => handleButtonClick(label)}
                            sx={{
                                paddingX: '15px',
                                color: activeButton === label ? '#f44336' : 'gray',
                                '&:hover': {
                                    backgroundColor: 'transparent',
                                },
                            }}
                        >
                            {label}
                        </Button>
                    ))}
                </Box>
            }
        >
            <Grid container sx={{ marginX: '-10px', width: 'auto' }}>
                {items.map((item, index) => (
                    <AnimeUpdateItem item={item} key={index} index={index} />
                ))}
            </Grid>
        </TitelItem>
    );
};

export default NominatedAnime;
