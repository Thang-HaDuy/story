import TitelItem from '@/components/content/TitelItem';
import Grid from '@mui/material/Grid';
import UpcommingItem, { IUpcommingItem } from './UpcommingItem';
import { IAnimeUpdateItem } from '../anime-update/AnimeUpdateItem';

const UpcommingAnime = () => {
    const items: IUpcommingItem[] = [
        {
            img: '/name2.jpg',
            views: '650,345',
            rating: 2.4,
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

    return (
        <TitelItem title="SẮP CHIẾU" childrenTitle={<></>}>
            <Grid container sx={{ marginX: '-10px', width: 'auto' }}>
                {items.map((item, index) => (
                    <UpcommingItem item={item} key={index} index={index} />
                ))}
            </Grid>
        </TitelItem>
    );
};

export default UpcommingAnime;
