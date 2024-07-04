import Box from '@mui/material/Box';
import TitleSidebar from '@/components/sidebar/item/TitleSidebar';
import Button from '@mui/material/Button';
import ItemAnimeHot from './ItemAnimeHot';

export interface IItemAnime {
    name: string;
    rating: number;
    className: string;
    img: string;
    date: string;
    quality: string;
    period: string;
}

const AnimeHot = () => {
    const itemAnime: IItemAnime[] = [
        {
            name: 'Anime1',
            rating: 4.3,
            className: 'Animehaha1',
            date: '2024-06-16 12:42:44.779',
            quality: 'FHD',
            img: '/name1.jpg',
            period: '6/7',
        },
        {
            name: 'Thanh Gươm Diệt Quỷ: Đại Trụ Đặc Huấn',
            rating: 4.3,
            className: 'Animehaha2',
            date: '2024-06-16 12:42:44.779',
            quality: 'FHD',
            img: '/name1.jpg',
            period: '6/7',
        },
        {
            name: 'Quái Vật Số 8',
            rating: 4.3,
            className: 'Animehaha3',
            date: '2024-06-16 12:42:44.779',
            quality: 'FHD',
            img: '/name1.jpg',
            period: '6/7',
        },
        {
            name: 'Anime1',
            rating: 4.3,
            className: 'Animehaha4',
            date: '2024-06-16 12:42:44.779',
            quality: 'FHD',
            img: '/name1.jpg',
            period: '6/7',
        },
        {
            name: 'Chuyển Sinh Thành Đệ Thất Hoàng Tử, Tôi Quyết Định Trau Dồi Ma Thuật',
            rating: 4.3,
            className: 'Animehaha5',
            date: '2024-06-16 12:42:44.779',
            quality: 'FHD',
            img: '/name1.jpg',
            period: '6/7',
        },
    ];

    let isActive: boolean = false;

    return (
        <Box sx={{ padding: '10px', marginBottom: '20px', backgroundColor: '#181d1f', borderRadius: '3px' }}>
            <TitleSidebar content={'HOT TUẦN'}>
                <Button
                    sx={{
                        marginLeft: '20px',
                        paddingX: '15px',
                        paddingY: '0',
                        fontSize: '14px',
                        fontWeight: '400',
                        color: isActive ? 'white' : '#f44336',
                        '&:hover': { backgroundColor: 'transparent' },
                    }}
                >
                    TV/Series
                </Button>
                <Button
                    sx={{
                        paddingX: '15px',
                        paddingY: '0',
                        fontSize: '14px',
                        fontWeight: '400',
                        color: isActive ? '#f44336' : 'white',
                        '&:hover': { backgroundColor: 'transparent' },
                    }}
                >
                    Movie/OVA
                </Button>
            </TitleSidebar>
            <Box>
                {itemAnime.map((item, index) => {
                    return <ItemAnimeHot key={index} item={item} index={index} />;
                })}
            </Box>
        </Box>
    );
};

export default AnimeHot;
