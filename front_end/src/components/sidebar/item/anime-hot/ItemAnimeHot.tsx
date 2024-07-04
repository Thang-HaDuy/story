import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import ImageMovie from '@/components/ui/ImageMovie';
import SelectHover from '@/components/ui/SelectHover';
import { IItemAnime } from './AnimeHot';
import InforList, { IInforItem } from '@/components/ui/InforList';

const ItemAnimeHot = ({ item, index }: { item: IItemAnime; index: number }) => {
    const iteminfor: IInforItem = {
        rating: item.rating,
        date: item.date,
        quality: item.quality,
        period: item.period,
        color: '#78909c',
    };

    return (
        <Box
            sx={{
                display: 'flex',
                marginBottom: '20px',
                '&:hover': {
                    [`& .i${item.className}`]: { display: 'flex' },
                    [`& .t${item.className}`]: { color: '#7d7d7d' },
                },
            }}
        >
            <Box
                sx={{
                    position: 'relative',
                    width: '55px',
                    marginRight: '10px',
                }}
            >
                <ImageMovie src={item.img} alt={item.img} />
                <SelectHover className={`i${item.className}`} />
                <Box
                    component="span"
                    sx={{
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        position: 'absolute',
                        top: '-4px',
                        left: '-5px',
                        backgroundColor: '#b5e745',
                        color: '#333',
                        fontSize: '9.6px',
                        fontWeight: '700',
                        height: '23px',
                        paddingX: '6px',
                        borderTopLeftRadius: '3px',
                        '&::before': {
                            content: '""',
                            position: 'absolute',
                            top: '0',
                            right: '-5px',
                            width: '100%',
                            borderBottom: '5px solid #b5e745',
                            borderRight: '5px solid transparent',
                            opacity: '0.7',
                        },
                    }}
                >
                    #{++index}
                    <Box
                        component="i"
                        sx={{
                            position: 'absolute',
                            right: '0',
                            left: '0',
                            bottom: '0',
                            '&::before': {
                                content: '""',
                                position: 'absolute',
                                top: '0',
                                left: '0',
                                borderTop: '5px solid #b5e745',
                                borderRight: '13px solid transparent',
                            },
                            '&::after': {
                                content: '""',
                                position: 'absolute',
                                top: '0',
                                right: '0',
                                borderTop: '5px solid #b5e745',
                                borderLeft: '15px solid transparent',
                            },
                        }}
                    />
                </Box>
            </Box>
            <Box>
                <Typography
                    className={`t${item.className}`}
                    sx={{
                        lineHeight: '20px',
                        fontSize: '13px',
                        fontWeight: '400',
                        maxWidth: { xs: 'auto', md: '215px' },
                        maxHeight: '40px',
                        cursor: 'pointer',
                        overflow: 'hidden',
                    }}
                >
                    {item.name}
                </Typography>
                <InforList item={iteminfor} />
            </Box>
        </Box>
    );
};

export default ItemAnimeHot;
